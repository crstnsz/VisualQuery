
namespace VisualQuery
{
    internal class ComboBoxIOwnerItem
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
