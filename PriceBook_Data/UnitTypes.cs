using System.Collections;
using System.Text;

namespace PriceBook_Data
{
    public class UnitTypes : IEnumerable<UnitType>
    {
        private readonly List<UnitType> _unitTypes = new List<UnitType>();


        public UnitTypes(bool loadAllFromDb = false)
        {
            if (loadAllFromDb)
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    _unitTypes = context.UnitType.ToList();
                }

                foreach (var ut in _unitTypes)
                {
                    ut.IsAttached = true;
                }
            }
        }

        public int Count => _unitTypes.Count;


        public UnitType this[int i] => _unitTypes[i];

        public IEnumerator<UnitType> GetEnumerator()
        {
            return _unitTypes.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (UnitType ut in _unitTypes)
            {
                builder.AppendLine(ut.ToString());
            }

            return builder.ToString();
        }

        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute] // satisfaction of IEnumerable does
        // not require coverage.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
