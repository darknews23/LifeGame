using System.Text;
using Life.Core.Events;
using Life.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class EatableImpl : Actions, IEatable
    {
        private readonly BeingEatenEvent _beingEatenEvent;
        private readonly IEventRecorder _eventRecorder;
        public IEatable EatableOwner { get; set; }
        public int Id { get; }
        public int BeingEatenDamage { get; }
        public bool IsFullyEatable { get; }
        public int Hp { get; set; }
        private readonly ILogger _logger;

        public EatableImpl(ILoggerFactory loggerFactory, BeingEatenEvent beingEatenEvent, IEventRecorder eventRecorder)
        {
            _logger = loggerFactory.CreateLogger<EatableImpl>();
            _beingEatenEvent = beingEatenEvent;
            _eventRecorder = eventRecorder;
        }

        public int GetEaten()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"{EatableOwner.GetType().Name}({EatableOwner.Id}) was eaten. Hp: {EatableOwner.Hp} -> ");

            int hpReturn;
            //todo: можно отказаться от isFullyEatable. (Но нужно ли?)
            //В таком случае, если урон равен здоровью, то объект по смыслу полностью съедобен.
            //Иначе существу будет нанесен фиксированный урон, и можно урон же и возвращать в качестве результата.
            if (EatableOwner.IsFullyEatable)
            {
                hpReturn = EatableOwner.Hp;
                EatableOwner.Hp = 0;
            }
            else
            {
                hpReturn = EatableOwner.BeingEatenDamage;
                EatableOwner.Hp -= EatableOwner.BeingEatenDamage;
            }
            stringBuilder.Append($"{EatableOwner.Hp}. ");

            _beingEatenEvent.ActorId = EatableOwner.Id;
            _beingEatenEvent.ActorType = EatableOwner.GetType();
            _beingEatenEvent.HpChange = hpReturn;
            _beingEatenEvent.StepNumber = GameSession.StepCount;

            _eventRecorder.Record(_beingEatenEvent);
            _logger.LogInformation(stringBuilder.ToString());

            return hpReturn;
        }
    }
}
