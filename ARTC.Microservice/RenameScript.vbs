oldName = "Microservice"
reservedLibKeyword = "Microservice.Utility"
reserveLibPlaceholder = "M!CR0$3RVIC3UT!L!TY"
newName = InputBox("Please enter new project root name")

If newName <> "" Then
	result = MsgBox ("Are you sure you want to rename all files and folder with "+oldName+" to "+newName+"?", vbYesNo, "Confirmation")

	Select Case result
	Case vbYes
		Set objFSO = CreateObject("Scripting.FileSystemObject")
		extensions = Array("csproj","sln","cs", "yml")
		ignoreFolders = Array(".vs", ".git")
		
		objStartFolder = objFSO.GetParentFolderName(WScript.ScriptFullName)
		Set objFolder = objFSO.GetFolder(objStartFolder)

		RenameFiles objFSO.GetFolder(objStartFolder)
		RenameFolders objFSO.GetFolder(objStartFolder)

		Sub RenameFiles(Folder)
			Set objFolder = objFSO.GetFolder(Folder.Path)
			Set colFiles = objFolder.Files
			For Each objFile in colFiles
				sNewFile = objFile.Name
				sNewFile = Replace(sNewFile, oldName, newName)
				newFilePath = objFile.ParentFolder+"\"+sNewFile
				If (sNewFile<>objFile.Name) Then 
					objFile.Move(newFilePath)
				End If

				Set objFileReader = objFSO.OpenTextFile(newFilePath, 1)
				If Ubound(Filter(extensions, LCase(objFSO.GetExtensionName(newFilePath)))) > -1 And Not objFileReader.AtEndOfStream Then 
					strText = objFileReader.ReadAll
					objFileReader.Close

					strNewText = Replace(strText, reservedLibKeyword, reserveLibPlaceholder)
					strNewText = Replace(strNewText, oldName, newName)
					strNewText = Replace(strNewText, reserveLibPlaceholder, reservedLibKeyword)
					Set objFileReader = objFSO.OpenTextFile(newFilePath, 2)

					objFileReader.Write strNewText

					objFileReader.Close
				End If
			Next
			For Each Subfolder in Folder.SubFolders
				Set objFolder = objFSO.GetFolder(Subfolder.Path)
				sNewFolder = objFolder.Name
				If Not Ubound(Filter(ignoreFolders, sNewFolder)) > -1 Then
					RenameFiles Subfolder
				End If
			Next
		End Sub

		Sub RenameFolders(Folder)
			For Each Subfolder in Folder.SubFolders
				Set objFolder = objFSO.GetFolder(Subfolder.Path)
				sNewFolder = objFolder.Name
				If Not Ubound(Filter(ignoreFolders, sNewFolder)) > -1 Then
					sNewFolder = Replace(sNewFolder, oldName, newName)
					If (sNewFolder<>objFolder.Name) Then 
						objFolder.Move(objFolder.ParentFolder+"\"+sNewFolder)
					End If
					RenameFolders Subfolder
				End If
			Next
		End Sub
		MsgBox("Operation Successful")
	Case vbNo
		MsgBox("Operation Cancelled")
	End Select
End If


