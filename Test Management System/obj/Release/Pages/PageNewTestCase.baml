   M S B A M L   `   `   `  ���� Q  MTest Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Test_Management_System.PagesTest_Management_System.Pages  2    ,Test_Management_System.Pages.PageNewTestCase   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     <local*clr-namespace:Test_Management_System.Pages       N� Title$  PageNewTestCase��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+��� -   $��Header��$��18(�$��0��$��10, 0, 10, 0q��� $��1��$��10q�$
��Left=�$��Заголовок *���� -   $��	TBSummary��$��1��$��10q�$��Right=� �� 	MaxLength$	 255��$	��980���� $��2�� �� Orientation$ 
Horizontal=�$��10q�.+��� $��0, 10, 93, 0q�$��Описание *���� -   $��TBDescription��$��80�� �� AcceptsReturn . $
 1000��" �� VerticalScrollBarVisibility$
 Auto=� �� TextWrapping$
 Wrap=�$	��390���� $��20, 0, 126, 0q�$��
Шаги *���� -   $��TBSteps��$��80�� . $	 255��$
 Auto=�$
 Wrap=�$	��390���� $��4��$ 
Horizontal=�$��10q�.+��� $��0, 0, 13, 0q�$-��'Ожидаемый результат *���� -   $��
TBExpected��$	��390��$��80�� . 
 � Tag$ required��$	 255��$
 Auto=�$
 Wrap=��� $��18, 0, 22, 0q�$/��)Фактический результат���� -   $��TBActual��$	��390��$��80�� . $
 Auto=�$	 255��$
 Wrap=��� $��5��$ 
Horizontal=�$��10q�.+��� $��Статус���� -   $��ComboStatusTC�� �� DisplayMemberPath$# TCStatusDescriptionTranlation��$	��390��$��127, 0, 20, 0q��� $��0, 0, 57, 0q�$#��Тестовые данные���� -   	 ��Name$	 
TBTestData��$	��390��$	 255���� $��6��$ 
Horizontal=�$��10q�.+��� $��0, 0, 75, 0q�$��Дата создания��(  "System.Windows.Controls.DatePicker  -	   $��CreationDate��$	��390���� $��20, 0, 95, 0q�$��Окружение���� -
   $��TBEnvironment��$	��390��$	 255���� $��7��$ 
Horizontal=�$��10q�.+��� $��Тип��$��0, 0, 144, 0q��� -   $��ComboTypeTC��$! TCTypeDescriptionTranlation��$	��390���� $��Поведение��$��20, 0, 97, 0q��� -   $��ComboBehaviorTC��$% TCBehaviorDescriptionTranlation��$	��390���� $��8��$ 
Horizontal=�$��10q�.+��� $��Приоритет��$��0, 0, 98, 0q��� -   $��ComboPriorityTC��$&  TCPriorityDescriptionTranslation��$	��390���� $��Критичность��$��20, 0, 87, 0q��� -   $��ComboSeverityTC��$&  TCSeverityDescriptionTranslation��$	��390���� $ 
Horizontal=�$��9��.+��� $��Вложения��$��10, 0, 10, 0q��� -   
 ��Name$
 AttachmentsListBox��$	��734��$��80��$��93, 10, 10, 10q����� .R��� $ 
Horizontal=�.+��� $��10q�$��14(�$��Courier)����� �� -   $��Удалить��$��10, 0q�$	��100��   RoundedCorners#���   �� -   $��AddAttachment��#���   $��10q�$	��200��$'��!Добавить вложение��$��35, 10, 10, 10q�$��Center=��� $��10��$ 
Horizontal=�$��10q�.+��� $��Предусловия��$��0, 0, 83, 0q��� -   $��TBPreconditions��$	��390��$��80��$	 255�� . $
 Auto=�$
 Wrap=��� $��Постусловия��$��20, 0, 87, 0q��� -   $��TBPostConditions��$��80��$
 Wrap=� . $	 255��$
 Auto=�$	��390���� $��11��$ 
Horizontal=�$��Right=�$��Bottom=�$��10, 10, 10, 20q�.+��� -   $��SaveAndBackToTCPageButton��#���   $	��200��$��10q�$��0, 0, 10, 0q�$&�� Сохранить и выйти���� -   $��SaveAndAddTCButton��#���   $	��250��$��10q�$��0, 0, 10, 0q�$<��6Сохранить и добавить ещё один���� -   $$��NoSaveBackToTestCasePageButton��#���   $	��200��$��10q�$,��&Выйти без сохранения��