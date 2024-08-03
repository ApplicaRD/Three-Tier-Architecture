namespace TemplateFileSystem.Utilities;

using System.Security;
using System.Windows;
using System.Windows.Controls;

public static class PasswordBoxHelper
{
    public static readonly DependencyProperty SecurePasswordBindingProperty = DependencyProperty.RegisterAttached(
        "SecurePassword",
        typeof(SecureString),
        typeof(PasswordBoxHelper),
        new FrameworkPropertyMetadata(new SecureString(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            AttachedPropertyValueChanged)
    );

    private static void AttachedPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not PasswordBox passwordBox) return;
        passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
        passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
    }

    private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (sender is PasswordBox passwordBox) SetSecurePassword(passwordBox, passwordBox.SecurePassword);
    }

    public static void SetSecurePassword(DependencyObject dp, SecureString value)
    {
        dp.SetValue(SecurePasswordBindingProperty, value);
    }

    public static SecureString GetSecurePassword(DependencyObject dp)
    {
        return (SecureString)dp.GetValue(SecurePasswordBindingProperty);
    }
}