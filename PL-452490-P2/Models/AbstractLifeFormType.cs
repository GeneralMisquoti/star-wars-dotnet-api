using System.Collections;
using System.Collections.Generic;

namespace PL_452490_P2.Models
{
    /// <summary>
    /// Required to be able to have families / trees of life form types,
    /// where some of them may not make sense. For example there is no
    /// Mammal type animal, but a cat, a dog, etc.
    /// </summary>
    public class AbstractLifeFormType
    {
        public int Id { get; set; }
        public string Name { get; set; }
#nullable enable
        public AbstractLifeFormType?
            ParentAbstractLifeFormType { get; set; }
        public int?
            ParentAbstractLifeFormTypeId { get; set; }
    }
}