<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Eclipsa.Master" AutoEventWireup="true" CodeBehind="EditWorkout.aspx.cs" Inherits="Eclipsa.EditWorkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<section class="first">
 <div class="container">
 <div class="row">
 <div class="col-xs-12 text-center">
 <h1>Create New 5-Step Workout</h1>
 </div>
 </div>
 <div class="form-horizontal">
 <div class="form-group">


     <asp:Label ID="WorkoutNamelabel" runat="server" Text="MAC"
                        AssociatedControlID="Workout" CssClass="col-xs-4 control-label"></asp:Label>
 <div class="col-xs-4">
      <asp:TextBox ID="Workout" runat="server" CssClass="form-control" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
 <div class="has-error">
 <span class="help-block">
     <asp:RequiredFieldValidator ID="WorkoutValidator1" runat="server" ErrorMessage="Name is Required"
                                    ControlToValidate="Workout" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
 </span>
 </div>
 </div>
 </div>




 <div class="form-group">
     <asp:Label ID="Step1ExLabel" runat="server" Text="Make"
                        AssociatedControlID="Step1Box" CssClass="col-xs-4 control-label"></asp:Label>
 <div class="col-xs-4">
      <asp:TextBox ID="Step1Box" runat="server" CssClass="form-control" TextMode="SingleLine" MaxLength="30"></asp:TextBox>
 <div class="has-error">
 <span class="help-block">
      <asp:RequiredFieldValidator ID="RequiredStep1Box" runat="server" ErrorMessage="Name is Required"
                                    ControlToValidate="Step1Box" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
 </span>
 </div>
 </div>
 </div>







 <div class="form-group">
      <asp:Label ID="NumofSetsLabel" runat="server" Text="Model"
                        AssociatedControlID="Sets1" CssClass="col-xs-4 control-label"></asp:Label>
 <div class="col-xs-2">
           <asp:TextBox ID="Sets1" runat="server" CssClass="form-control" TextMode="SingleLine" MaxLength="30"></asp:TextBox>

 <div class="has-error">
 <span class="help-block">
     <asp:RequiredFieldValidator ID="NumofSets1Label" runat="server" ErrorMessage="Sets is Required"
                                    ControlToValidate="Sets1" Display="Dynamic" ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
   
 </span>
 </div>
 </div>




</div>

 </div>
 <div class="form-group">
 <div class="col-xs-4 col-xs-offset-4">

      <asp:Button ID="WorkoutEditButton" runat="server" Text="Submit" CssClass="btn btn-success"
                            OnClick="WorkoutEditButton_Click" ValidationGroup="AllValidators" />
 <asp:hyperlink cssclass="btn btn-default" navigateurl="~/Workout.aspx" runat="server" text="Back" />
 </div>
 </div>
 </div>

 </section>





</asp:Content>
