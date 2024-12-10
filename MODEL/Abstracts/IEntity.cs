using MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Abstracts
{
    public interface IEntity<T>
    {
        
        //ID
        public int ID { get; set; }
        public T MasterID { get; set; }
        //CreatedDate
        public DateTime CreatedDate { get; set; }

        //CreatedComputerName
        public string CreatedComputerName { get; set; }
        //CreatedIPAddress
        public string CreatedIpAddress { get; set; }//162.168.1.1


        //UpdatedDate
        public DateTime? UpdatedDate { get; set; }
        //UpdatedComputerName
        public string? UpdatedComputerName { get; set; }
        //UpdtedIPAddress
        public string? UpdatedIpAddress { get; set; }

        //Status // Active-Passive
        public DataStatus Status { get; set; } //todo: Constructor
    }
}
