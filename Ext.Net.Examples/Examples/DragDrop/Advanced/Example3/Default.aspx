<%@ Page Language="C#" %>

<%@ Import Namespace="System.Collections.Generic"%>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientStore.DataSource = new List<object>
                                      {
                                          new {InsuranceCode="11111", Name="Fred Bloggs", Address="Main Street", Telephone="555 1234 123"},
                                          new {InsuranceCode="22222", Name="Fred West", Address="Cromwell Street", Telephone="666 666 666"},
                                          new {InsuranceCode="33333", Name="Fred Mercury", Address="Over The Rainbow", Telephone="555 321 0987"},
                                          new {InsuranceCode="44444", Name="Fred Forsyth", Address="Blimp Street", Telephone="555 111 2222"},
                                          new {InsuranceCode="55555", Name="Fred Douglass", Address="Talbot County, Maryland", Telephone="N/A"}
                                      };
        PatientStore.DataBind();

        HospitalStore.DataSource = new List<object>
                                      {
                                          new {Code="AAAAA", Name="Saint Thomas", Address="Westminster Bridge Road, SE1 7EH", Telephone="020 7188 7188"},
                                          new {Code="BBBBB", Name="Queen's Medical Centre", Address="Derby Road, NG7 2UH", Telephone="0115 924 9924"},
                                          new {Code="CCCCC", Name="Saint Bartholomew", Address="West Smithfield, EC1A 7BE", Telephone="020 7377 7000"},
                                          new {Code="DDDDD", Name="Royal London", Address="Whitechapel, E1 1BB", Telephone="020 7377 7000"}
                                      };
        HospitalStore.DataBind();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Drag&amp;Drop - Ext.NET Examples</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .app-header .x-panel-body {
            background-color: #99BBE8;
        }

        .app-header h1 {
            font-family: verdana,arial,sans-serif;
            font-size: 20px;
        }

        .hospital-target {
            border: 1px solid red;
            width: 400px;
            height: 30px;
        }

        .hospital-target.hospital-target-hover {
            background-color: #D88;
        }

        .patient-source {
            cursor: pointer;
        }

        .patient-view td {
            font-family: verdana,arial,sans-serif;
            font-size: 12px;
        }

        td.patient-label {
            background-color: #ddd;
            border: 1px solid #bbb;
            font-weight: bold;
            text-align: right;
            width: 100px;
            padding: 0px 3px 0px 0px;
        }
    </style>
    
    <script type="text/javascript">
        var getDragData = function (e) {
            var sourceEl = e.getTarget(PatientView.itemSelector, 10);
            
            if (sourceEl) {
                d = sourceEl.cloneNode(true);
                d.id = Ext.id();
                
                return PatientView.dragData = {
                    sourceEl    : sourceEl,
                    repairXY    : Ext.fly(sourceEl).getXY(),
                    ddel        : d,
                    patientData : PatientView.getRecord(sourceEl).data
                }
            }
        };

        var getRepairXY = function () {
            return this.dragData.repairXY;
        };
        
        var getTargetFromEvent = function (e) {
            return e.getTarget(".hospital-target");
        };

        var onNodeEnter = function (target, dd, e, data) { 
            Ext.fly(target).addClass("hospital-target-hover");
        };

        var onNodeOut = function (target, dd, e, data) { 
            Ext.fly(target).removeClass("hospital-target-hover");
        };

        var onNodeOver = function (target, dd, e, data) { 
            return this.dropAllowed;
        };

        var onNodeDrop = function (target, dd, e, data) {
            var rowIndex = HospitalGrid.getView().findRowIndex(target);
            var h = HospitalGrid.getStore().getAt(rowIndex);
            Ext.Msg.alert("Drop gesture", "Dropped patient " + data.patientData.Name +
                " on hospital " + h.data.Name);
            return true;
        };
    </script>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <ext:Viewport runat="server" Layout="border">
            <Items>
                <ext:Container 
                    runat="server" 
                    Cls="app-header" 
                    Height="100"
                    Region="North" 
                    Html="<h1>Patient Hospital Assignment</h1>" 
                    Margins="5"
                    />
                <ext:Panel runat="server" Title="Patients" Width="300" Region="West" Margins="0 5 5 5">
                    <Items>
                        <ext:DataView 
                            ID="PatientView" 
                            runat="server"
                            Cls="patient-view"
                            ItemSelector="div.patient-source"
                            >
                            <Store>
                                <ext:Store ID="PatientStore" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="InsuranceCode">
                                            <Fields>
                                                <ext:RecordField Name="Name" />
                                                <ext:RecordField Name="Address" />
                                                <ext:RecordField Name="Telephone" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>                                    
                            </Store>
                            <Template runat="server">
                                <Html>
									<tpl for=".">
										<div class="patient-source">
											<table>
												<tbody>
													<tr>
														<td class="patient-label">Name</td>
														<td class="patient-name">{Name}</td>
													</tr>
													<tr>
														<td class="patient-label">Address</td>
														<td class="patient-name">{Address}</td>
													</tr>
													<tr>
														<td class="patient-label">Telephone</td>
														<td class="patient-name">{Telephone}</td>
													</tr>
												</tbody>
											 </table>
										 </div>
									 </tpl>
								 </Html>
                            </Template>
                        </ext:DataView>
                    </Items>
                </ext:Panel>
            
                <ext:GridPanel 
                    ID="HospitalGrid" 
                    runat="server"
                    Title="Hospitals"
                    Region="Center"
                    Margins="0 5 5 0"
                    >
                    <Store>
                        <ext:Store ID="HospitalStore" runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="Code">
                                    <Fields>
                                        <ext:RecordField Name="Name" />
                                        <ext:RecordField Name="Address" />
                                        <ext:RecordField Name="Telephone" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column DataIndex="Name" Header="Name" Width="200" />
                            <ext:Column DataIndex="Address" Header="Address" Width="300" />
                            <ext:Column DataIndex="Telephone" Header="Telephone" Width="100" />
                        </Columns>
                    </ColumnModel>
                    
                    <View>
                        <ext:GridView runat="server" EnableRowBody="true">
                            <GetRowClass Handler="rowParams.body = '<div class=\'hospital-target\'></div>';" />
                        </ext:GridView>
                    </View>
                </ext:GridPanel>
            </Items>
        </ext:Viewport>
        
        <ext:DragZone runat="server" Target="={PatientView.getEl()}">
            <GetDragData Fn="getDragData" />
            <GetRepairXY Fn="getRepairXY" />
        </ext:DragZone>
        
        <ext:DropZone runat="server" Target="={HospitalGrid.getView().scroller}">
            <GetTargetFromEvent Fn="getTargetFromEvent" />
            <OnNodeEnter Fn="onNodeEnter" />
            <OnNodeOut Fn="onNodeOut" />
            <OnNodeOver Fn="onNodeOver" />
            <OnNodeDrop Fn="onNodeDrop" />
        </ext:DropZone>
    </form>    
</body>
</html>