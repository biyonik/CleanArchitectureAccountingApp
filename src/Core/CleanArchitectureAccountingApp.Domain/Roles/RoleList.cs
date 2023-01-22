using CleanArchitectureAccountingApp.Domain.AppEntities.Identity;

namespace CleanArchitectureAccountingApp.Domain.Roles;

public sealed class RoleList
{
    public static List<AppRole> GetStaticRoles()
    {
        List<AppRole> appRoles = new()
        {
            #region UniformChartOfAccount

            new(Title: UniformChartOfAccount, Code: UniformChartOfAccountCreateCode,
                Name: UniformChartOfAccountCreateName),
            new(Title: UniformChartOfAccount, Code: UniformChartOfAccountUpdateCode,
                Name: UniformChartOfAccountUpdateName),
            new(Title: UniformChartOfAccount, Code: UniformChartOfAccountRemoveCode,
                Name: UniformChartOfAccountRemoveName),
            new(Title: UniformChartOfAccount, Code: UniformChartOfAccountReadCode,
                Name: UniformChartOfAccountReadName)

            #endregion
        };

        return appRoles;
    }

    #region Role Code and Names

    public static string UniformChartOfAccountCreateCode = "UniformChartOfAccount.Create";
    public static string UniformChartOfAccountCreateName = "Hesap planı kayıt";

    public static string UniformChartOfAccountUpdateCode = "UniformChartOfAccount.Update";
    public static string UniformChartOfAccountUpdateName = "Hesap planı güncelle";

    public static string UniformChartOfAccountRemoveCode = "UniformChartOfAccount.Remove";
    public static string UniformChartOfAccountRemoveName = "Hesap planı silme";

    public static string UniformChartOfAccountReadCode = "UniformChartOfAccount.Read";
    public static string UniformChartOfAccountReadName = "Hesap planı görüntüle";

    #endregion

    #region Role Title Names

    public static string UniformChartOfAccount = "Hesap Planı";

    #endregion
}