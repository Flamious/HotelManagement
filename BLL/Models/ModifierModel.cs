using DAL;

namespace BLL.Models
{
    public class ModifierModel
    {
        public int ModifierID { get; set; }
        public string ModifierName { get; set; }
        public ModifierModel() { }
        public ModifierModel(Modifier modifier)
        {
            ModifierID = modifier.ModifierId;
            ModifierName = modifier.ModifierName;
        }
    }
}
