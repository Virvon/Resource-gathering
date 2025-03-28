using Sources.Infrastructure;
using UnityEngine;

namespace Sources.Services.Configurations
{
    [CreateAssetMenu(fileName = "BankConfiguration", menuName = "Configuration/Create new bank configuration")]
    public class BankConfiguration : ScriptableObject
    {
        public ResourceCell[] Cells;
    }
}