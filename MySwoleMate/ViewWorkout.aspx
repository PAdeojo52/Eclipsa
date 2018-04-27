<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Eclipsa.Master" AutoEventWireup="true" CodeBehind="ViewWorkout.aspx.cs" Inherits="Eclipsa.ViewWorkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    




    <section class="first">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 text-center">
                    <h1>Assign Equipment</h1>
                </div>
            </div>
            <div class="form-horizontal">

<div class="form-group">
                    <asp:Label ID="AssignWorkouts" runat="server" Text=""
                        AssociatedControlID="WorkoutID" CssClass="col-xs-4 control-label"></asp:Label>
                    <div class="col-xs-4">
                        <asp:DropDownList ID="WorkoutID" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <div class="has-error">
                            <span class="help-block">
                                <asp:RequiredFieldValidator ID="WorkoutRequired" runat="server" ErrorMessage="Workout is Required" InitialValue="-1"
                                    ControlToValidate="WorkoutID" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                            </span>
                        </div>
                    </div>
                </div>

   
             <div class="form-group">
                    <div class="col-xs-4 col-xs-offset-4">
                           <asp:Button ID="AssignWorkout_Click" runat="server" Text="Remove" CssClass="btn btn-success"
                            OnClick="RemoveButton_Click" ValidationGroup="AllValidators" />


                        <asp:HyperLink CssClass="btn btn-default" NavigateUrl="~/Trainees.aspx" runat="server" Text="Back" />


                        </div>
                </div>
                   </div>
        </div>
    </section>
                
</asp:Content>
