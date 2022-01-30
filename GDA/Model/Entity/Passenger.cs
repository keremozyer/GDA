using GDA.Concern.Enums;

namespace GDA.Model.Entity
{
    public class Passenger
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public Document DocumentData { get; set; }

        public Passenger(Guid id)
        {
            this.ID = id;
        }
    }
}
