<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenuSite.Master" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="IntelligentCBD.Company.EditCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript" src="/js/jquery-1.4.4.min.js"></script>
<script type="text/javascript" src="/js/xheditor-1.2.2.min.js"></script>
<script type="text/javascript" src="/js/xheditor_lang/zh-cn.js"></script>
    <table style="width:800px;">
            <tr>
                <td class="TableTitle" colspan="2">编辑企业</td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 90px;">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="height: 20px; width: 90px;"></td>
                <td style="height: 20px; width: 150px;"></td>
                <td style="height: 20px; width: 80px;"></td>
                <td style="height: 20px; width: 90px;"></td>
                <td style="height: 20px; "></td>
                <td style="height: 20px; "></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 23px;">企业名称：</td>
                <td style="height: 23px; color: #FF6600;" colspan="3">
                    <span class="SearchNotice">此处信息可被检索出</span><br />
                    <asp:TextBox ID="TextBox_CompanyName" runat="server" MaxLength="100" Width="330px"></asp:TextBox>
                </td>
                <td style="height: 23px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_CompanyName" Display="Dynamic" ErrorMessage="企业名称不能为空" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td style="height: 23px"></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 23px;">注册资本：</td>
                <td class="auto-style1" style="width: 150px; height: 23px;">
                    <asp:TextBox ID="TextBox_Capital" runat="server" MaxLength="7" TextMode="Number" Width="100px"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList_Units" runat="server">
                        <asp:ListItem>亿</asp:ListItem>
                        <asp:ListItem Selected="True">万</asp:ListItem>
                        <asp:ListItem>千</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="height: 23px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox_Capital" Display="Dynamic" ErrorMessage="请输入正确的注册资本" ForeColor="Red" ValidationExpression="^\+?[1-9][0-9]{0,6}$">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 23px; width: 90px">所属行业：</td>
                <td style="height: 23px">
                    <asp:TextBox ID="TextBox_Industry" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">物业面积：</td>
                <td class="auto-style1" style="width: 150px; height: 20px;">
                    <asp:TextBox ID="TextBox_Area" runat="server" MaxLength="10" TextMode="Number" Width="120px"></asp:TextBox>
                    ㎡</td>
                <td style="height: 20px; width: 80px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox_Area" Display="Dynamic" ErrorMessage="请输入正确的物业面积" ForeColor="Red" ValidationExpression="^\+?[1-9][0-9]{0,6}$">*</asp:RegularExpressionValidator>
                </td>
                <td style="height: 20px; width: 90px">房 间 号：</td>
                <td style="height: 20px">
                    <asp:TextBox ID="TextBox_RoomNum" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">企业地址：</td>
                <td class="auto-style1" style="height: 20px;" colspan="2">
                    <asp:TextBox ID="TextBox_Address" runat="server" MaxLength="100" Width="250px"></asp:TextBox>
                    </td>
                <td style="height: 20px">
                    所属载体：</td>
                <td style="height: 20px">
                    <asp:DropDownList ID="DropDownList_Vector" runat="server" DataSourceID="SqlDataSourceVector" DataTextField="载体名称" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceVector" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [载体名称], [ID] FROM [载体]"></asp:SqlDataSource>
                </td>
                <td style="height: 20px"></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 160px;">企业简介：</td>
                <td class="auto-style2" style="height: 160px;" colspan="2"><span class="SearchNotice">此处信息可被检索出</span>
                    <br />
                    <asp:TextBox ID="TextBox_Introduction" runat="server" CssClass="text" Height="130px" TextMode="MultiLine" Width="225px" MaxLength="500"></asp:TextBox>
                </td>
                <td style="width: 90px; height: 160px">
                    经营范围：</td>
                <td style="height: 160px" class="auto-style3"><span class="SearchNotice">此处信息可被检索出</span>
                    <br />
                    <asp:TextBox ID="TextBox_BusinessScope" runat="server"  CssClass="text" Height="130px" TextMode="MultiLine" Width="225px" MaxLength="500"></asp:TextBox>
                </td>
                <td style="height: 160px" class="auto-style3">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 20px;">注册地：</td>
                <td class="auto-style1" style="width: 150px; height: 20px;">
                    <asp:TextBox ID="TextBox_RegisteredAddress" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 20px; width: 80px">
                </td>
                <td style="width: 90px; height: 20px">
                    注册日期：</td>
                <td style="height: 20px">
                    <asp:TextBox ID="TextBox_RegistrationDate" runat="server" MaxLength="30" TextMode="Date" Width="168px"></asp:TextBox>
                </td>
                <td style="height: 20px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 21px;">联系人：</td>
                <td class="auto-style1" style="width: 150px; height: 21px;">
                    <asp:TextBox ID="TextBox_Contact" runat="server" MaxLength="30"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 21px; width: 80px">
                </td>
                <td style="width: 90px; height: 21px">
                    联系电话：</td>
                <td style="height: 21px">
                    <asp:TextBox ID="TextBox_Phone" runat="server" MaxLength="30"></asp:TextBox>
                </td>
                <td style="height: 21px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 18px;">电子邮箱：</td>
                <td class="auto-style1" style="width: 150px; height: 18px">
                    <asp:TextBox ID="TextBox_Email" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
                    <br />
                </td>
                <td style="height: 18px; width: 80px;">
                    </td>
                <td style="height: 18px; width: 90px;">
                    QQ：</td>
                <td style="height: 18px">
                    <asp:TextBox ID="TextBox_QQ" runat="server" MaxLength="30"></asp:TextBox>
                    &nbsp;</td>
                <td style="height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 90px; height: 30px;"></td>
                <td style="height: 30px; " colspan="2">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
                <td style="height: 30px; width: 90px;"></td>
                <td style="height: 30px"></td>
                <td style="height: 30px"></td>
            </tr>
            <tr>
                <td style="width: 90px; height: 30px;">宣传内容：</td>
                <td style="height: 30px; " colspan="2">
                    &nbsp;</td>
                <td style="height: 30px; width: 90px;">&nbsp;</td>
                <td style="height: 30px">&nbsp;</td>
                <td style="height: 30px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="5" >
                   <textarea name="content" id="elm1" class="xheditor {tools:'simple',upImgUrl:'upload/upload.aspx',upImgExt:'jpg,jpeg,gif,png'}" runat="server" maxlength="1000000" style="height: 300px; width: 680px"></textarea></td>
                <td style="height: 21px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px">&nbsp;</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:Label ID="LabelNotice" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 80px">
                    &nbsp;</td>
                <td style="width: 90px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 90px">&nbsp;</td>
                <td class="auto-style1" style="width: 150px">
                    <asp:Button ID="Next" runat="server" Text="下一步" OnClick="Next_Click" />
                &nbsp;</td>
                <td style="width: 80px">
                    &nbsp;</td>
                <td style="width: 90px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>
