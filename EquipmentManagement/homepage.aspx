<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="EquipmentManagement.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <center>
            <img src="imgs/qm.png" class="img-fluid" width="1000" height="300"/>
         </center>
   </section>
    <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Features</h2>
                  <p><b>Our 2 Primary Features -</b></p>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-6">
               <center>
                  <img width="150px" src="imgs/digital-inventory.png"/>
                  <h4>Read Notes</h4>
                  <p class="text-justify">It will let user read their notes.</p>
               </center>
            </div>
            <div class="col-md-6">
               <center>
                  <img width="150px" src="imgs/search-online.png"/>
                  <h4>Add notes</h4>
                  <p class="text-justify">This feature will let user enter notes in the app.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
</asp:Content>