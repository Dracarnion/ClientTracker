using BrightstarDB.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace Client_Tracker_MVC.Models
{
    [Entity]
    public interface IClient
    {
        [Required]
        string Id { get; }
        [Required(ErrorMessage = "Please enter the client's name")]
        string Name { get; set; }
        bool MedsRequested { get; set; }
        bool MedsRequestPaid { get; set; }
        bool MedsReceived { get; set; }
        [Required]
        string ModifiedDate { get; set; }
        string Notes { get; set; }
    }
}