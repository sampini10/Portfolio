   M S B A M L   `   `   `  ����E  AProjectWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ProjectWpf
ProjectWpf  5   	       ProjectWpf.Update   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ProjectWpf     5   	     � Title$  Update��5   	   $	��438��6   $	��271��6%    � WindowStartupLocation$ CenterScreen=�5	   	    � Icon$ /Img/LogoBack.png��6.    � 
ResizeMode$ NoResize=�6G    � WindowStyle$
 None=�6]   ���#7aa9a7.��5      �� -   5         ��Name$ 
panelTurno��5      $��Center=�6%   $��0,0,0,10q�6B   .+�5   
   �� $
��Bold"�6   $��	PACIENTE:��6"   ���#3A3B3C$��25��6K   �� 5   
   ���#3A3B3C$��Nombre��6%   �� 5   
   -   5         ��Name$ txtName��5      $��20��6#   $	��183��6/   $
��Left=�6;   4  .System.Windows.Automation.AutomationProperties   IsRequiredForForm . ���#CFD8DC6�   �� 5   
   ���#3A3B3C$��Apellido��6%   �� 5   
   -   5        $ 
txtSurname��5      $��20��6&   $	��183��62    . $
��Left=�6m   ���#CFD8DC6�   �� 5   
   ���#3A3B3C$��Obra Social��6%   �� 5   
   -   5         ��Name$ 
cmbOSocial��5      $��20��6'   $	��183��63    . $
��Left=�6m   ���#CFD8DC.@�5      �� $
��OSDE��6   �� 5      $��SwissMedical��6   �� 5      $��Galeno��6   5      �� 5   
   ���#3A3B3C$��Especialista:��6%   �� 5   
   -   5        $ cmbEspecialista��5      ���#CFD8DC$	��183��6A   $
��left=�6M   �� 5   
   ���#3A3B3C$��Fecha:��6%   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 fecha��5      $	��187��6$   $
��Left=�60   ���#3A3B3C
   SelectedDateFormat$
 Short=�6`   �� 5   
   ���#3A3B3C$��Hora:��6%   �� 5   
   -   5        $ cmbHora��5      $��20��6$   $	��170��60    . $
��Left=�6j   ���#CFD8DC.@�5      �� $��12:00��6   �� 5      $��13:00��6   �� 5      $��14:00��6   �� 5       $��15:00��6   5!      �� 5"   
   $��10(�6   $&�� *Los datos deben estar completos��6   �� 5#   
   �� 5$   
   -   5           RoundedButton#���   5$      $	��100��69   $��30��6E   ���#aadbd8���#3A3B3C$��Modificar Turno��6{   6�   �� 5%   
   $��10��6   6"   �� 5&   
   -	   5        #���   5&      $	��100��69   $��30��6E   ���#aadbd8���#3A3B3C$��Cancelar��6{   6�   5'      5(      