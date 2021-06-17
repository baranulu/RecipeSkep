using System;
using System.Collections.Generic;
using System.Text;

namespace LezizTariflerSepeti.Entity.Core
{
    public interface ICoreEntity { }

    public abstract class CoreEntity : ICoreEntity
    {
        public CoreEntity()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedComputer = Environment.MachineName;
            this.CreatedIp = "127.0.0.61";

        }

        public DateTime CreatedDate { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedComputer { get; set; }
    }
}
