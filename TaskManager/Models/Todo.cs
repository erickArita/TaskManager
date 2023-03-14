using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class Todo
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public String Title { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(87, MinimumLength = 5, ErrorMessage = "La descripción debe tener entre 5 y 87 caracteres")]
    public String Description { get; set; }

    [Required(ErrorMessage = "El valor es requerido")]
    [DataType(DataType.DateTime, ErrorMessage = "La fecha no es válida")]
    public DateTime EndDate { get; set; }
}