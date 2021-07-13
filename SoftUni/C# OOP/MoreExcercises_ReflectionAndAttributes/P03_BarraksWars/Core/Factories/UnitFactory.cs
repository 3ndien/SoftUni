namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;
    using P03_BarraksWars.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var fullName = typeof(Unit).Namespace;
            var typeOfUnit = Type.GetType(fullName + "." + unitType, false, true);
            var instanceOfUnit = (IUnit)Activator.CreateInstance(typeOfUnit);

            return instanceOfUnit;
        }
    }
}
