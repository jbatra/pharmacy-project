namespace Nuvem.PharmacyManagementSystem.Pharmacy.Services.Models;

public static class MappingHelper<T1, T2>
{
    public static T1 Map(T2 source)
    {
        T1 targetItem = Activator.CreateInstance<T1>();
        var props = typeof(T2).GetProperties();
        var targetProps = typeof(T1).GetProperties();
        foreach (var prop in props)
        {
            foreach (var targetProp in targetProps)
            {
                if (prop.Name == targetProp.Name)
                {
                    targetProp.SetValue(targetItem, prop.GetValue(source));

                }
            }
        }
        return targetItem;
    }
}