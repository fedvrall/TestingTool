   M S B A M L   `   `   `  ����Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  5   	   '    !Test_Management_System.Pages.Auth   5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Test_Management_System.Pages     5   	     � Title$  Авторизация��5   	   $	��470��6   $	��310��6*      CustomWindowStyle#���   66    � WindowStartupLocation$ CenterScreen=�6b   $	��310��6�   $	��310��6�   $	��470��6�   $	��470��6�   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5   
   A� $	��120��6   $	��120��6   ��5      �� 5       �� ImageSource$ /Pages/image.jpg��6   5      5      �� 5   
    �� Orientation$ Vertical=�6   $��Center=�6,   $��1��6I   .+�5      �� $&�� Добро пожаловать!��6   $��18(�61   $��Center=�6?   �� 5      $B��<Введите логин и пароль для входа.��6   $��Center=�6@   5      �� 5    
   $��2��6   $ 
Horizontal=�6"   .+�5!      �� $��
Логин��6   $��
10,10,10,0q�6%   �� 5"      -   5         ��Name$ textBoxLogin��5"   +   $��20,10,10,10q�6   $��	IvanAdmin��6B   $	��200��6S   5#      �� 5$   
   $��3��6   $ 
Horizontal=�6"   .+�5%      �� $��Пароль��6   $��
10,10,10,0q�6&   G� 5&      -   5         G�Name$ PasswordBox��5&   &   $	��200��6    G� Password$ 	Admin_123��6;   $��Center=�6P   $��10,10,10,10q�6r   �� 5'      -   5        $ TBPass��5'   "   $	��200��6   $y�	Collapsed=�62   $��10,10,10,10q�6I   5(      �� 5)   
   -   5         ��Name$ ShowPasswordCheckBox��5)   ;   $��4��6   $#��Показать пароль��6!   $��Center=�6�   $��26,10,30,10q�6�   ���#ffffff6�   �� 5*   
   -   5        $��LoginButton��5*   d   $��10q�6     RoundedCorners#���  6   $��5��6G   $��
Войти��6T   $��20,10,20,10q�6w   6�   5+      5,      