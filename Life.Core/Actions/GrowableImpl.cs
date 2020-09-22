using System.Text;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.Parameters;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class GrowableImpl : Actions, IGrowable
    {
        private readonly GrowthEvent _growthEvent;
        private readonly IEventRecorder _eventRecorder;

        public int CurrentAge {
            get => GrowableOwner.CurrentAge;
            set
            {
                GrowableOwner.CurrentAge = value;
                if (!GrowableOwner.IsEverGrowing && GrowableOwner.CurrentAge >= GrowableOwner.AdultAge)
                {
                    _growthEvent.BecameAdult = true;
                    Status = Status.Adult;
                }
                else
                {
                    _growthEvent.BecameAdult = false;
                }
            }
        }
        public int AdultAge { get; set; }
        public Status Status {
            get => GrowableOwner.Status;
            set
            {
                if (GrowableOwner.Status == Status.Child && value == Status.Adult)
                {
                    _logger.LogInformation($"{GetType().Name}({Id}) Became Adult.");
                }
                GrowableOwner.Status = value;
            }
        }
        public int Id { get; set; }
        public bool IsEverGrowing { get; }
        public int Hp { get; set; }
        public IGrowable GrowableOwner { get; set; }
        private readonly ILogger _logger;
        private readonly StringBuilder _stringBuilder;

        public GrowableImpl(ILoggerFactory loggerFactory, GrowthEvent growthEvent, IEventRecorder eventRecorder)
        {
            _growthEvent = growthEvent;
            _eventRecorder = eventRecorder;
            _logger = loggerFactory.CreateLogger<GrowableImpl>();
            _stringBuilder = new StringBuilder();
        }

        public void Grow()
        {
            if (GrowableOwner.Status == Status.Child)
            {
                CurrentAge++;

                _stringBuilder.Clear();
                _stringBuilder.Append($"{GrowableOwner.GetType().Name}({GrowableOwner.Id}) grew.  Hp: {GrowableOwner.Hp} -> ");

                var hpChange = 10;
                GrowableOwner.Hp += hpChange;

                _growthEvent.ActorId = GrowableOwner.Id;
                _growthEvent.ActorType = GrowableOwner.GetType();
                _growthEvent.HpChange = hpChange;
                _growthEvent.StepNumber = GameSession.StepCount;
                _eventRecorder.Record(_growthEvent);

                _stringBuilder.Append($"{GrowableOwner.Hp}\n");
                _logger.LogInformation(_stringBuilder.ToString());
            }

        }
    }
}
