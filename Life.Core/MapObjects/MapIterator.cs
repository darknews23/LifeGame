using System.Linq;
using Life.Core.Interfaces;

namespace Life.Core.MapObjects
{
    public class MapIterator
    {
        private IMap Map { get; }

        public MapIterator(IMap map)
        {
            Map = map;
        }
        //todo: сделать коллекцию действий и итерироваться по ней (можно класс или enum или др.)
        /*В идеале свести все к следующему:
         *  foreach(var action in actions)
         *  {
         *      Map.GameObjects.OfType<action>().ToList().ForEach(x => x?.Act());
         *  }
         * но action является переменной, а не типом. Так что так нельзя + Act() должен быть делегатом, который нужно будет менять?
        */
        private void DoActions()
        {
            Map.GameObjects.OfType<IMovable>().ToList().ForEach(x => x?.Move());
            Map.UpdateGameObjectsAndTiles();

            Map.GameObjects.OfType<IGrowable>().ToList().ForEach(x => x?.Grow());

            Map.GameObjects.OfType<IEater>().ToList().ForEach(x => x?.Eat());

            Map.GameObjects.OfType<IFemale>().ToList().ForEach(x => x?.ProgressPregnancy());
            Map.UpdateGameObjectsAndTiles();

            Map.GameObjects.OfType<IMale>().ToList().ForEach(x => x?.InitiateReproduction());
        }

        public void TakeNextStep()
        {
            Map.UpdateGameObjectsAndTiles();
            DoActions();
            Map.UpdateGameObjectsAndTiles();
        }
    }
}
