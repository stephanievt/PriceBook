namespace PriceBook_Data
{
    public class Units 
    {

        private readonly List<Unit> _units = new List<Unit>();

        public Units(bool loadFromDb = false)
        {
            if (loadFromDb)
            {
                ApplicationContext context = new ApplicationContext();
                _units = context.Unit.ToList();
            }
        }

        public Units(UnitType unitType)
        {
            ApplicationContext context = new ApplicationContext();
            _units = context.Unit.Where(u => u.UnitTypeId == unitType.Id).ToList();
        }

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public int Count => _units.Count;

        public bool IsIn(int id)
        {
            foreach (var currentUnit in _units)
            {
                if (currentUnit.Id == id) return true;
            }

            return false;
        }

        public Unit this[int i] => _units[i];

    }
}
