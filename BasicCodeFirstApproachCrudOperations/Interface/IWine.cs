namespace BasicCodeFirstApproachCrudOperations.Interface
{
    public interface IWine
    {
        List<IWine> Beers();
        List<IWine> Wine();
        List<IWine> Whiksy();
        List<IWine> Imported();
    }
}
