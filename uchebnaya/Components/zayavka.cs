//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace uchebnaya.Components
{
    using System;
    using System.Collections.Generic;
    
    public partial class zayavka
    {
        public string zayavka_nomer { get; set; }
        public int disciplina_id { get; set; }
    
        public virtual disciplina disciplina { get; set; }
    }
}