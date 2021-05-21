set exschemapath=
set schemapath=
set wsdlpath=
set out=""
"dotnet-svcutil" "%wsdlpath%SnapshotPull.wsdl" -v Debug --sync --noStdLib  --serializer XmlSerializer --outputFile SnapshotPullSvc.cs --namespace "*,DatexII" "%exschemapath%DATEXII_3_MessageContainer.xsd" "%exschemapath%DATEXII_3_ExchangeInformation.xsd" "%schemapath%DATEXII_3_Common.xsd" "%schemapath%DATEXII_3_D2Payload.xsd" "%schemapath%DATEXII_3_LocationReferencing.xsd" "%schemapath%DATEXII_3_RoadTrafficData.xsd" "%schemapath%DATEXII_3_Situation.xsd"
pause