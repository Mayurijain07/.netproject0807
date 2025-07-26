<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> web page</title>
</head>
<body>
    <form id="form1" runat="server">
       <table>
           <tr>
               <td> Name</td>
               <asp:HiddenField ID="hdn" runat="server"  />
               <td> <asp:TextBox  ID="txtName" runat="server" Required></asp:TextBox></td>
           </tr>

            <tr>
         <td> Age</td>
          <td> <asp:TextBox  ID="txtAge" runat="server" Required ></asp:TextBox></td>
        </tr>


           <tr>
               <th> Courses</th>
               <td><asp:DropDownList ID="ddleCourses" runat="server">
                   <asp:ListItem Text="--Select Value--" Value=""></asp:ListItem>
                   <asp:ListItem Text="Ba" Value="Ba"></asp:ListItem>
                   <asp:ListItem Text="Bca" Value="Bca"></asp:ListItem>
                   <asp:ListItem Text="Mca" Value="Mca"></asp:ListItem>

                   </asp:DropDownList></td>
           </tr>

           <tr>
               <th> Gender</th>
               <td><asp:RadioButtonList ID="rdGender" runat="server"> 
                   <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                   <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                   <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                   </asp:RadioButtonList></td>
               
           </tr>
           <tr>
               <td> City </td>
               <td> <asp:CheckBoxList ID="chkCity" runat="server" >
                   <asp:ListItem Text="Delhi" Value="Delhi"></asp:ListItem>
                   <asp:ListItem Text="Mumbai" Value="Mumabai"></asp:ListItem>
                   <asp:ListItem Text="Up" Value="Up"></asp:ListItem>
                    </asp:CheckBoxList></td>
               
           </tr>




           <tr>
               <td><asp:Button  ID="btnsave" runat="server" Text="Submit" OnClick="btnsave_Click"/></td>
           </tr>
       </table>

        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand"> 
            <Columns>
                
                <asp:TemplateField HeaderText="Name">
                   <ItemTemplate >
                 <%#Eval("name") %>
                  </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Age">
                     <ItemTemplate >
                 <%#Eval("age") %>
                 </ItemTemplate>
                     </asp:TemplateField>


                     <asp:TemplateField HeaderText="Courses">     
                   <ItemTemplate>
               <%#Eval("courses") %>
                       </ItemTemplate>
                   </asp:TemplateField>



                                     <asp:TemplateField HeaderText="Gender">     
                                          <ItemTemplate>
                                   <%# Eval("gender") %>
                       </ItemTemplate>
                   </asp:TemplateField>


                                  <asp:TemplateField HeaderText="City">     
                       <ItemTemplate>
                <%# Eval("city") %>
    </ItemTemplate>
</asp:TemplateField>

                


                <asp:TemplateField HeaderText="Action" >
                   <ItemTemplate >
                 <asp:LinkButton Id="btnDelete" runat="server" Text="Delete" CommandName="DeleteData" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                     <ItemTemplate >
                   
                 <asp:LinkButton Id="btnEdit" runat="server" Text="Edit" CommandName="EditRecord" CommandArgument='<%#Eval("id") %>'></asp:LinkButton>
               </ItemTemplate>
                    </asp:TemplateField>
                
                
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
