using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactLearningWebApi.Repositories
{
    public abstract class DBEntity
    {
        [Key]
        public string Id
        {
            get; private set;
        }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset ModifiedOn { get; set; }

        public DBEntity(string id, DateTimeOffset createdOn, DateTimeOffset modifiedOn)
        {
            Id = id;
            CreatedOn = createdOn;      
            ModifiedOn = modifiedOn;
        }

        public DBEntity(string id)
        {
            Id = id;
            CreatedOn = DateTimeOffset.UtcNow;
            ModifiedOn = DateTimeOffset.UtcNow;
        }

        public DBEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTimeOffset.UtcNow;
            ModifiedOn = DateTimeOffset.UtcNow;
        }
    }
}
