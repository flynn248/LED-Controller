namespace Led.Database.Ef.Infrastructure.Interface;

internal interface IDateMetadataUtc
{
  DateTime CreatedDateUtc { get; set; }
  DateTime? ModifiedDateUtc { get; set; }
}
