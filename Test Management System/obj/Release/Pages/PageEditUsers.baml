   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  0    *Test_Management_System.Pages.PageEditUsers   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageEditUsers��.���  � RowDefinitions �� $
��Auto ��� $��* ��� $��60 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $1��+Просмотр пользователей��$��0��$��16(�$
��Bold"�$��10, 10q�$
��Left=��� -   $��	userInfo1�� �� Orientation$ 
Horizontal=�$��3��$��10, 10, 0, 10q�$
��Left=� � DataContext ��  �� ElementName$ dgvUsers�� �� Path$ SelectedValue�.+��� $��Имя���� -   $��FirstNameTextBox�� �� 
IsReadOnly . $	��150�� �� 	MaxLength$ 25��$��	79,0,10,0q����� $ 	FirstName��� $��Фамилия���� -   $��LastNameTextBox�� . $	��150��$ 25��$��	86,0,10,0q����� $ LastName��� $��Роль���� -   $��RoleComboBox�� �� 
IsReadOnly . 	 �� DisplayMemberPath$	 RoleNameTranslation��$	��200��$��	10,0,10,0q�$��Center=�
 �� SelectedIndex
 �� *Role.RoleID+$��14(��� $ 
Horizontal=�$��4��$��10, 10, 0, 10q�$
��Left=� �� $ dgvUsers��$ SelectedValue�.+��� $��Логин:���� -   $��LoginTextBox�� . $	��150��$��	64,0,10,0q�$ 20������ $ Login��� -   $��	PassLabel��$!��Текущий пароль��G� -   $��PassBox��{�.  $	��150�� G� 	MaxLength$ 20��$��	38,0,10,0q��� -    ��Name$ PassTextBox��$	��150��$��	38,0,10,0q�$ 20�� . $y�	Collapsed=��� -	   $��ShowCurrentPass��$#��Показать пароль��$��10, 0q��� -
   $��
ChangePass��$#��Изменить пароль��$��4��$��Right=�$��10q�$	��150��   RoundedCorners#���   $y�	Collapsed=��� -    ��Name$ NewPassBlock��$ 
Horizontal=�$��5��$��10, 10, 0, 10q�$
��Left=�.+��� -   $��NewPassLabel��$��Новый пароль��G� -   $��NewPass��$	��150��$��	13,0,10,0q�$ 20���� -   $ NewPassTextBox��$	��150��$��	13,0,10,0q�$ 20��$y�	Collapsed=��� $)��#Подтвердите пароль��G� -   $��NewPassAgreement��$	��150��$��	10,0,10,0q�$ 20���� -   $ NewPassAgreementTextBox��$	��150��$��	10,0,10,0q�$ 20��$y�	Collapsed=��� -   $��ShowNewPass��$#��Показать пароль��$��10, 0q��� -   $��	reminder1��$r��lПароль должен состоять из 8-20 символов латинского алфавита,��$��
10,0, 0, 0q�$��6��$y�	Collapsed=��� -   $��	reminder2��$z��tсодержать как минимум: 1 заглавную букву, 1 цифру и 1 из символов: ��$��10, 15, 10, 10q�$��6��$y�	Collapsed=��� -   $��	reminder3��$e��_!@#$%^_*()/.- А так же не содержать популярных комбинаций.��$��10, 30, 10, 10q�$��6��$y�	Collapsed=��� $ 
Horizontal=�$��6��$��Right=�$��0, 20, 10, 20q�.+��� -   $��	AddButton��$��Добавить��$	��150��$��0, 0, 10, 0q�#���   �� -   $��
SaveButton��$��Сохранить��$	��150��$��0, 0, 10, 0q�{�.  #���   �� -   $��
EditButton��$ ��Редактировать��$	��150��$��0, 0, 10, 0q�{�.  #���   �� -   $��DeleteButton��$��Удалить��$	��150��{�.  #���   &   System.Windows.Controls.DataGrid  -   $��dgvUsers��   SelectionMode$ Single=�   
IsReadOnly .    AutoGenerateColumns .  $��10q�$��1��   HeadersVisibility$ Column=�   CanUserAddRows .  ����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Имя��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	FirstName+   ElementStyle �� .���  �� Property � �� �� Value$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Фамилия��$	 150  �� *
LastName+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ 
Логин��$	 120  �� *Login+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�  $ Пароль��$	 120    
Visibility$ Hidden=� �� *
Password+  $ Роль��$	 170  �� *Role.RoleNameTranslation+ �� .���  � ��$
 Wrap=���  � ��$ Center=���  � ��$ 5,5,0,0q�