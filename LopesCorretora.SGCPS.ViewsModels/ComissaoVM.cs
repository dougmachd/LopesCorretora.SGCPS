using System;
using System.Collections.Generic;
using System.Text;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class ComissaoVM
    {
        public List<PlanoMOD> LisPlanosMOD { get; set; }
        public ComissaoMOD ObjComissaoMOD { get; set; }
    }
}
