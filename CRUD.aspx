<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WEB_FORM_CRUD.CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WEB_FORM CRUD</title>
    <link href="Contents/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Contents/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <div class="container py-4">
                <div class="mb-3">
                    <h1 class="form-label fw-bold">Form</h1>
                    <input type="hidden" id="ID" value="<%=ID %>" />
                </div>
                <div class="mb-3">
                    <label for="FirstName" class="form-label">First Name</label>
                    <input type="text" class="form-control" id="FirstName" name="FirstName" autocomplete="off" value="<%=FirstName %>" />
                </div>
                <div class="mb-3">
                    <label for="LastName" class="form-label">Last Name</label>
                    <input type="text" class="form-control" id="LastName" name="LastName" autocomplete="off" value="<%=LastName %>" />
                </div>
                <div class="mb-3">
                    <label for="MobileNo" class="form-label">Mobile No.</label>
                    <input type="number" class="form-control" id="MobileNo" name="MobileNo" autocomplete="off" value="<%=MobileNo %>" />
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
            </div>
        </section>
        <br />
        <hr />
        <br />
        <section>
            <div class="container">
                <div class="mb-3">
                    <h1 class="form-label fw-bold">List</h1>
                </div>
                <table class="table">
                    <thead>
                        <tr>
                            <th scope="col">#</th>
                            <th scope="col">First Name</th>
                            <th scope="col">Last Name</th>
                            <th scope="col">Mobile Number</th>
                            <th scope="col">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%if (dt.Rows.Count > 0)
                            {%>
                        <%for (int IntI = 0; IntI < dt.Rows.Count; IntI++)
                            {%>
                        <tr>
                            <td><%=dt.Rows[IntI]["ID"] %></td>
                            <td><%=dt.Rows[IntI]["FirstName"] %></td>
                            <td><%=dt.Rows[IntI]["LastName"] %></td>
                            <td><%=dt.Rows[IntI]["MobileNo"] %></td>
                            <td>
                                <button type="button" class="btn btn-primary" onclick="Action('Edit','<%=dt.Rows[IntI]["ID"] %>')">Edit</button>
                                <button type="button" class="btn btn-primary" onclick="Action('Delete','<%=dt.Rows[IntI]["ID"] %>')">Delete</button>
                            </td>
                        </tr>
                        <%} %>
                        <%}
                        else
                        {%>
                        <tr>
                            <td colspan="4">No Record Found!</td>
                        </tr>
                        <%}%>
                    </tbody>
                </table>
            </div>
        </section>
    </form>
    <script>
        function Action(Action, ID) {
            window.location.href = "CRUD.aspx?ID=" + ID + "&Action=" + Action; 
        }
    </script>
</body>
</html>
