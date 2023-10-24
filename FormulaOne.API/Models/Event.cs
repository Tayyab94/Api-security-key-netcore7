﻿namespace FormulaOne.API.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get;set; }

        public List<Ticket> Tickets {  get; set; }  
    }
}
