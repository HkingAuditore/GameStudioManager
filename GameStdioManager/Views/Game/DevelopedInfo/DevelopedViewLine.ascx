<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DevelopedViewLine.ascx.cs" Inherits="GameStdioManager.Views.Game.DevelopedInfo.DevelopedViewLine" %>
<%@ Register Src="~/Views/Game/DevelopedInfo/Developer.ascx" TagPrefix="uc1" TagName="Developer" %>


<div class="row" style="padding-top: 1%; padding-bottom: 1%; border-bottom: 2px solid rgba(112, 112, 112, 0.12)">
    <div class="col-lg-1">
        <asp:Label ID="C_GameNumber" runat="server" Text="编号"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameName" runat="server" Text="名字"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameStartDevelopTime" runat="server" Text="开发日期"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameProcess" runat="server" Text="完成日期"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameFun" runat="server" Text="趣味性"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameArt" runat="server" Text="美术"></asp:Label>
    </div>
    <div class="col-lg-1">
        <asp:Label ID="C_GameMusic" runat="server" Text="音乐"></asp:Label>
    </div>
    <div class="col-lg-3">
        <div class="row">
            <div runat="server" ID="C_Developers">

            </div>
        </div>
    </div>
    <div class="col-lg-2">
        <div class="row">
            <div id="pic<%= LineGame.GameNumber %>" style="width: 300px; height: 300px;"></div>
            <script type="text/javascript">
                DrawChart();

                function DrawChart() {
                    var myChart = echarts.init(document.getElementById('pic<%= LineGame.GameNumber %>'));
                    var option = {
//                    title: {
//                        text: '能力值'
//                    },
                        tooltip: {
                            trigger: 'axis'
                        },
                        legend: {
                            left: 'center',
                            data: ['趣味性', '美术', '音乐']
                        },
                        radar: [
                            {
                                indicator: [
                                    { text: '趣味性', max: 600 },
                                    { text: '美术', max: 600 },
                                    { text: '音乐', max: 600 }
                                ],
                                center: ['50%', '50%'],
                                radius: 150,
                                splitArea: {
                                    areaStyle: {
                                        color: ['#B8D3E4', '#96C5E3', '#7DB5DA', '#72ACD1']
                                    }
                                },
                                axisTick: {
                                    show: true,
                                    lineStyle: {
                                        color: 'rgba(255, 255, 255, 0.8)'
                                    }
                                },
                                axisLabel: {
                                    show: true,
                                    textStyle: {
                                        color: 'white'
                                    }
                                },
                                axisLine: {
                                    lineStyle: {
                                        color: 'rgba(255, 255, 255, 0.4)'
                                    }
                                },
                                splitLine: {
                                    lineStyle: {
                                        color: 'rgba(255, 255, 255, 0.4)'
                                    }
                                }
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
                                        value: [
                                            <%= LineGame.GameFun %>, <%= LineGame.GameArt %>, <%= LineGame.GameMusic %>
                                        ],
                                        name: '<%= LineGame.GameName %>'
                                    }
                                ]
                            }
                        ]

                    };

                    // 使用刚指定的配置项和数据显示图表。
                    myChart.setOption(option);

                }
            </script>

        </div>
    </div>
</div>