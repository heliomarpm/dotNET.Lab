using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Sample.Aleatorios
{
    /// <summary>
    /// Verificar acesso ao diretorio do Windows
    /// Exemplo de uso:
    /// if (!UserSecurityDirectory.HasAccess(new DirectoryInfo(temp), System.Security.AccessControl.FileSystemRights.CreateDirectories))
    /// {
    ///     MessageBox.Show("Sem permissão ao caminho " + temp, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
    ///     return;
    ///  }
    /// </summary>

    public class UserSecurityDirectory
    {
        static WindowsIdentity _currentUser;
        static WindowsPrincipal _currentPrincipal;

        static UserSecurityDirectory()
        {
            _currentUser = WindowsIdentity.GetCurrent();
            _currentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
        }

        public static bool HasAccess(DirectoryInfo directory, FileSystemRights right)
        {
            // Obtem a lista de regras que se aplica ao diretorio
            AuthorizationRuleCollection acl = directory.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
            return HasFileOrDirectoryAccess(right, acl);
        }

        public static bool HasAccess(FileInfo file, FileSystemRights right)
        {
            // Obtem a lista de regras que se aplica ao arquivo
            AuthorizationRuleCollection acl = file.GetAccessControl()
                .GetAccessRules(true, true, typeof(SecurityIdentifier));
            return HasFileOrDirectoryAccess(right, acl);
        }

        private static bool HasFileOrDirectoryAccess(FileSystemRights right, AuthorizationRuleCollection acl)
        {
            bool allow = false;
            bool inheritedAllow = false;
            bool inheritedDeny = false;

            for (int i = 0; i < acl.Count; i++)
            {
                FileSystemAccessRule currentRule = (FileSystemAccessRule)acl[i];
                // Se usuario atual tem essa permissão
                if (_currentUser.User.Equals(currentRule.IdentityReference) ||
                    _currentPrincipal.IsInRole((SecurityIdentifier)currentRule.IdentityReference))
                {

                    if (currentRule.AccessControlType.Equals(AccessControlType.Deny))
                    {
                        if ((currentRule.FileSystemRights & right) == right)
                        {
                            if (currentRule.IsInherited)
                            {
                                inheritedDeny = true;
                            }
                            else
                            {
                                //Sem acesso
                                return false;
                            }
                        }
                    }
                    else if (currentRule.AccessControlType.Equals(AccessControlType.Allow))
                    {
                        if ((currentRule.FileSystemRights & right) == right)
                        {
                            if (currentRule.IsInherited)
                            {
                                inheritedAllow = true;
                            }
                            else
                            {
                                allow = true;
                            }
                        }
                    }
                }
            }

            if (allow)
            {
                //Permissao negada
                return true;
            }
            return inheritedAllow && !inheritedDeny;
        }
    }
}

