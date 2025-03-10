using Microsoft.AspNetCore.Mvc;

namespace Application.DTO.Pagination;

public class SortModel
{
    /// <summary>
    /// Название поля в БД, по которому нужно провести сортировку, при необходимости.
    /// </summary>
    /// <example>id</example>
    [BindProperty(Name = "order_by")]
    public string? OrderBy { get; set; } = "Id";
    /// <summary>
    /// Направление сортировки. Валидные значения: "asc","desc". По умолчанию = asc
    /// </summary>
    /// <example>asc</example>
    [BindProperty(Name = "ordering")]
    public string Ordering { get; set; } = "asc";

}