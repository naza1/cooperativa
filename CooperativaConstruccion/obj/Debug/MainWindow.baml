   M S B A M L   `   `   `  ����R  NCooperativaConstruccion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CooperativaConstruccionCooperativaConstruccion  5   	   (    "CooperativaConstruccion.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:CooperativaConstruccion     5   	     � Title$"  Cooperativa de Construcción��5   	    � WindowState$ 	Maximized=�6-    � 
ResizeMode$ CanMinimize=�6E    � Icon$ Icon.ico��6^   .��5	      � .+�5
   
   �� $
��Bold"�6   $
��Left=�6&   $��
160,60,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $��	PROYECTOS��6�   �� 5   
   -   5        $��TotalGastos��5   �   $
��Bold"�6   $��Right=�6&   $��	0,60,30,0q�6B   $
��Wrap=�6U   $	��Top=�6i   6�   �� 5   
   -   5        $��grillaProyectos��5   3   $
��Auto��6J   $��160,90,0,30q�6X   $��Stretch=�6m   $
��Left=�6�   ��6   �� *	Updates+ �� View 5      �� 5      .P�5      �� $��Proyecto��6H    �� Width 6%   ��  �� Path$ ActualWidth� �� DisplayMemberBinding 6Z   �� $ Id��� 5      $��Nombre��6H    6%   �� $ ActualWidth� 6X   �� $
 Name��� 5      $��Monto Inicial��6H    6%   �� $ ActualWidth� 6_   �� $ StartBudget��� 5      $��Monto Actual��6H    6%   �� $ ActualWidth� 6^   �� $ CurrentBudget��� 5      $��Fecha Inicio��6H    6%   �� $ ActualWidth� 6^   �� $ 	StartDate��� 5      $��	Fecha Fin��6H    6%   �� $ ActualWidth� 6[   �� $ EndDate��� 5      $��Estado��6H    6%   �� $ ActualWidth� 6X   �� $ Status��� 5      $��Días Restantes��6H    6%   �� $ ActualWidth� 6`   �� $ RemainingDays�5      ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value$
 14(�61   �� 5      	 � ��$
 Normal$�62   �� 5      	 � ��$

 Bold"�63   �� 5      	 � ��

 �   �63   �� 5      	 � ��

 �   �64   �� 5       	 � ��$
 Center=�6C   �� 5!      	 � ��$
 0,0,0,1q�68   5"      5$      �� 5%   
   -   5        $��button_NewProject��5%      $��Crear Proyecto��6*   $
��Left=�6C   $��
20,120,0,0q�6^   $	��Top=�6r   $	��106��6�   6�   �� 5&   
   -   5        $��button_EditProject��5&      $��Modificar Proyecto��6+   $
��Left=�6H   $��
20,150,0,0q�6c   $	��Top=�6w   $	��106��6�   6�   �� 5'   
   -   5        $��button_DeleteProject��5'      $��Eliminar Proyecto��6-   $
��Left=�6I   $��
20,180,0,0q�6d   $	��Top=�6x   $	��106��6�   6�   �� 5(   
   -   5        $��button_NewExpense��5(      $��Agregar Gasto��6*   $
��Left=�6B   $��
20,280,0,0q�6]   $	��Top=�6q   $	��106��6�   6�   �� 5)   
   -   5        $��button_EditExpense��5)      $��Modificar Gasto��6+   $
��Left=�6E   $��
20,310,0,0q�6`   $	��Top=�6t   $	��106��6�   6�   �� 5*   
   -   5        $��button_DeleteExpense��5*      $��Eliminar Gasto��6-   $
��Left=�6F   $��
20,340,0,0q�6a   $	��Top=�6u   $	��106��6�   6�   �� 5+   
   -	   5        $��button_CloseMainWindow��5+      $��Cerrar��6/   $
��Left=�6@   $��
20,440,0,0q�6[   $	��Top=�6o   $	��106��6�   6�   �� 5,   
   -
   5        $��button_Help��5,      $��Ayuda��6$   $
��Left=�64   $��20,470,0,60q�6O   $��Bottom=�6d   $	��106��6   6�   �� 5-   
   -   5        $��button_About��5-      $��Acerca��6%   $
��Left=�66   $��20,500,0,30q�6Q   $��Bottom=�6f   $	��106��6�   6�   �� 5.   
   -   5        $��grillaGastos��5.   3   $
��Auto��6G   $��
0,91,29,29q�6U   $��Stretch=�6i   $��Right=�6�   ��6   �� *	Updates+ 5/      �� 50      .P�51      �� $��Código��6H    6%   �� $ ActualWidth� 6X   �� $ Id��� 52      $��Nombre��6H    6%   �� $ ActualWidth� 6X   �� $
 Name��� 53      $��Cantidad��6H    6%   �� $ ActualWidth� 6Z   �� $ Amount��� 54      $��Precio Unitario��6H    6%   �� $ ActualWidth� 6a   �� $ 	UnitPrice��� 55      $��Precio Total��6H    6%   �� $ ActualWidth� 6^   �� $ 
TotalPrice�56      ��58      �� 59      " ��6   .�5:      �� 	 � ��$
 14(�61   �� 5;      	 � ��$
 Normal$�62   �� 5<      	 � ��$

 Bold"�63   �� 5=      	 � ��

 �   �63   �� 5>      	 � ��

 �   �64   �� 5?      	 � ��$
 Center=�6C   �� 5@      	 � ��$
 0,0,0,1q�68   5A      5C      5D      5E      