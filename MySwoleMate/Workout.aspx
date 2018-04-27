<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Eclipsa.Master" AutoEventWireup="true" CodeBehind="Workout.aspx.cs" Inherits="Eclipsa.Workout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>





   

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
 <section class="first">
    <div class="container">
         <div class="row">
             <div class="col-xs-10">
                 <h1>Equipment Page</h1>
            </div>
            <div class="col-xs-2">
               <a href="~/AddWorkout.aspx" runat="server" class="btn btn-success">Add New Equipment</a>
            </div>
        </div>
     

 <div class="row">
    <div class="col-lg-12 text-center">
         <asp:GridView ID="WorkoutList" runat="server" CssClass="table table-bordered text-left"
                        AutoGenerateColumns="False" OnRowDeleting="WorkoutList_RowDeleting" DataKeyNames="WorkoutID">
                        <Columns>
                         
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="WorkoutID"
                                DataNavigateUrlFormatString="~/EditWorkout.aspx?WorkoutID={0}" ControlStyle-CssClass="btn btn-success btn-xs"
                                ItemStyle-CssClass="text-center" />
                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="DeleteButton" CommandName="Delete"
                                        CssClass="btn btn-xs btn-default" Text="Delete"
                                        OnClientClick="if(!confirm('Are you sure you wish to delete this workout?')) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Mac" HeaderText="Mac" />
                            <asp:BoundField DataField="Make" HeaderText="Make" />
                            <asp:BoundField DataField="Model" HeaderText="Model" />
                            <asp:BoundField DataField="ISCheckedOut" HeaderText="Checked Out"/>
                            <asp:BoundField DataField="NineNumber" HeaderText="NineNumber"/>
                        
                        </Columns>
                    </asp:GridView>
                </div>
             </div>
           </div>
    </section>
</asp:Content>
