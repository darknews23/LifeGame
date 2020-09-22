using System.Linq;
using System.Text;
using Life.Core.Events;
using Life.Core.Interfaces;
using Life.Core.MapObjects;
using Life.Core.Parameters;
using Microsoft.Extensions.Logging;

namespace Life.Core.Actions
{
    public class MaleImpl : Actions, IMale
    {
        private readonly ReproductionEvent _reproductionEvent;
        private readonly IEventRecorder _eventRecorder;
        public IMale MaleImplOwner { get; set; }
        public IMap Map { get; }
        public Coordinates Coordinates { get; set; }
        public int Id { get; }
        private readonly ILogger _logger;
        private readonly StringBuilder _stringBuilder;
        public MaleImpl(ILoggerFactory loggerFactory, ReproductionEvent reproductionEvent, IEventRecorder eventRecorder)
        {
            _reproductionEvent = reproductionEvent;
            _eventRecorder = eventRecorder;
            _logger = loggerFactory.CreateLogger<MaleImpl>();
            _stringBuilder = new StringBuilder();
        }


        public void InitiateReproduction()
        {
            _stringBuilder.Clear();
            var females = MaleImplOwner.Map.Tiles
                .First(x=>x.Coordinates.Equals(MaleImplOwner.Coordinates))
                .GameObjectsOnTile
                .OfType<IGender>()
                .Where(x =>
                    x.Status == Status.Adult &&
                    x.GetType() == MaleImplOwner.GetType() &&
                    x.GenderType == GenderType.Female &&
                    x.IsPregnant == false)
                .ToList<IFemale>();
            if (females.Count > 0)
            {
                int index = GameSession.Random.Next(0, females.Count);
                _stringBuilder.Append(
                    $"{MaleImplOwner.GetType().Name}({MaleImplOwner.Id}) initiated reproduction with {MaleImplOwner.GetType().Name}({females[index].Id})\n");
                females[index].GetPregnant();

                _reproductionEvent.ActorId = MaleImplOwner.Id;
                _reproductionEvent.ActorType = MaleImplOwner.GetType();
                _reproductionEvent.FemaleId = females[index].Id;
                _reproductionEvent.StepNumber = GameSession.StepCount;

                _eventRecorder.Record(_reproductionEvent);

                _logger.LogInformation(_stringBuilder.ToString());
            }
        }
    }
}
