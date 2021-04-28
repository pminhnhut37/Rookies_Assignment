import React from "react";
import { Switch, Route } from "react-router-dom";
//page comp
import Dashboard from "./pages/dashboard/Dashboard.js";
import Products from "./pages/products/Product.js";
import Category from "./pages/categories/Category.js";
import Users from "./pages/users/User.js";
import NotMatch from "./pages/errors/NoMatch.js";
import AddProduct from "./pages/products/addProduct_form.js"

export default function Routes(props) {
  return (
    <Switch>
      <Route exact path="/">
        <Dashboard />
      </Route>
      <Route path="/products">
        <Products />
      </Route>
      <Route path="/categories">
        <Category />
      </Route>
      <Route path="/users">
        <Users />
      </Route>
      <Route path="/addProducts/:id">
        <AddProduct />
      </Route>
      <Route path="/addProducts">
        <AddProduct />
      </Route>
      <Route path="*">
        <NotMatch />
      </Route>
    </Switch>
  );
} 