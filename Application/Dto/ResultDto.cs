namespace Application.Dto;

public class ResultDto <T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
}