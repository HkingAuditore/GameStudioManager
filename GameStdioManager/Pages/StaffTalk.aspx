<%@ Page Title="" Language="C#" MasterPageFile="~/Views/StaffPage.master" AutoEventWireup="true" CodeBehind="StaffTalk.aspx.cs" Inherits="GameStdioManager.Pages.StaffTalk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StaffContentPlaceHolder" runat="server">
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-2">
                    员工【<asp:Label ID="L_StaffName" runat="server" Text="请选择要对话的员工"></asp:Label>】
                </div>
                <div class="col-lg-1">
                    <asp:DropDownList ID="D_Staff" runat="server" DataSourceID="GameStudioSimulator" DataTextField="StaffName" DataValueField="StaffNumber" OnSelectedIndexChanged="D_Staff_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    <asp:SqlDataSource ID="GameStudioSimulator" runat="server" ConnectionString="<%$ ConnectionStrings:ConString %>" SelectCommand="SELECT
                                                                                                                                                    	StaffInfo.StaffNumber,
                                                                                                                                                    	StaffInfo.StaffName 
                                                                                                                                                    FROM
                                                                                                                                                    	StaffInfo 
                                                                                                                                                    WHERE
                                                                                                                                                    	StaffInfo.StaffStudio = @StaffStudio">
                        <SelectParameters>


                            <asp:SessionParameter DefaultValue="0" Name="StaffStudio" SessionField="PlayerStudioNumber" Type="String"/>

                        </SelectParameters>
                    </asp:SqlDataSource>

                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <asp:Label ID="L_StaffTalkContent" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </div>
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">
        <div class="col-lg-12">

            <div class="row">
                <div class="col-lg-6">
                    <div id="Ability" style="width: 600px; height: 300px;"></div>
                </div>
                <div class="col-lg-6">
                    <div id="CheckLog" style="width: 600px; height: 300px;"></div>
                </div>
                <script type="text/javascript">
                    
                    var abilityChart = echarts.init(document.getElementById('Ability'));
                    var option = {
                        title: {
                            text: '能力值'
                        },
                        tooltip: {
                            trigger: 'axis'
                        },
                        legend: {
                            left: 'center',
                            data: ['体力', '智力', '忠诚']
                        },
                        radar: [
                            {
                                indicator: [
                                    { text: '体力', max: 60 },
                                    { text: '智力', max: 110 },
                                    { text: '忠诚', max: 110 }
                                ],
                                center: ['50%', '50%'],
                                radius: 80
                            }
                        ],
                        series: [
                            {
                                type: 'radar',
                                tooltip: {
                                    trigger: 'item'
                                },
                                areaStyle: {},
                                data: [
                                    {
                                        value: [<%=GetStaffHP()%>, <%=GetStaffIntelligence()%>, <%=GetStaffLoyalty()%>],
                                        name: '<%=GetStaffName()%>'
                                    }
                                ]
                            }
                        ]

                    };



                    // 使用刚指定的配置项和数据显示图表。
                    abilityChart.setOption(option);
                </script>
                <script type="text/javascript">
                    Draw();

                    function GetCheckTime(hour, isWork) {
                        var t;
                        $.ajax({
                            url: "StaffTalk.aspx/GetStaffCheck",
                            type: "POST",
                            dataType: "json",
                            async: false,    //异步
                            contentType: "application/json; charset=utf-8",
                            data: "{hour:'" + hour + "',isWork:'" + isWork + "'}",
                            success: function (data) {
                                t = data.d;
                            },
                            error: function () {
                                alert("统计出错！");
                            }
                        });
                        console.log("t" + t);
                        return t;
                    }

                    function GetCheckTimes(isWork) {
                        var t;
                        $.ajax({
                            url: "StaffTalk.aspx/GetStaffCheckArray",
                            type: "POST",
                            dataType: "json",
                            async: false,    //异步
                            contentType: "application/json; charset=utf-8",
                            data: "{isWork:'" + isWork + "'}",
                            success: function (data) {
                                console.log("data" + data.d);
                                t = data.d;
                                console.log("data T:" + t);

                            },
                            error: function () {
                                alert("统计出错！");
                            }
                        });
                        console.log("t" + t);
                        return t;
                    }

                    function GetCheckTimeArray(isWork) {
                        return new Array(24).fill('').map((item, index) => GetCheckTime(index + 1, isWork));
                    }

                    function Draw() {
                        var checkLogChart = echarts.init(document.getElementById('CheckLog'));
                        console.log("ARRAY:" + GetCheckTimeArray(true));
                        console.log("RETURN:" + GetCheckTime(9, true));

                        var option = {
                            color: ['#5793f3', '#d14a61'],
                            title: {
                                text: '上下班打卡时间分布'
                            },
                            tooltip: {
                                trigger: 'axis',
                                axisPointer: {
                                    type: 'cross'
                                }
                            },
                            grid: {
                                right: '20%'
                            },
                            toolbox: {
                                feature: {
                                    dataView: { show: true, readOnly: false },
                                    restore: { show: true },
                                    saveAsImage: { show: true }
                                }
                            },
                            xAxis: {
                                name: '时间',
                                type: 'category',
                                data: new Array(24).fill('').map((item, index) => index + ':00'),
                                axisPointer: {
                                    type: 'shadow'
                                }
                            },
                            yAxis: {
                                type: 'value',
                                name: '打卡次数',
                                axisLabel: {
                                    formatter: '{value} 次'
                                }

                            },
                            series: [{
                                data: GetCheckTimes(true)  ,
                                type:'bar',
                                name:'上班打卡次数'
                            },{
                                data: GetCheckTimes(false) ,
                                type:'bar',
                                name:'下班打卡次数'
                            }]
                        };
                        // 使用刚指定的配置项和数据显示图表。
                        checkLogChart.setOption(option);
                    }
                </script>
            </div>
        </div>
    </div>
    <div class="row" style="margin: 2%; padding: 2%; border-radius: 10px; border: 2px solid rgba(33, 33, 33, 0.67)">


        <div class="col-lg-1">
            <asp:Button ID="B_Reward" runat="server" Text="奖励" OnClick="B_Reward_OnClick" CssClass="btn btn-primary"/>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="B_Penalize" runat="server" Text="惩罚" OnClick="B_Penalize_OnClick" CssClass="btn btn-primary"/>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="B_Promote" runat="server" Text="升职" OnClick="B_Promote_OnClick" CssClass="btn btn-primary"/>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="B_Demote" runat="server" Text="降职" OnClick="B_Demote_OnClick" CssClass="btn btn-primary"/>
        </div>
        <div class="col-lg-1">
            <asp:Button ID="B_Fire" runat="server" Text="辞退" OnClick="B_Fire_OnClick" CssClass="btn btn-primary"/>
        </div>


    </div>

</asp:Content>