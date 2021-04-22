import React from "react";
import { Switch, Route } from "react-router-dom";
//page comp
import Dashboard from "./pages/dashboard/Dashboard";
import Order from "./pages/orders/Order";
import Product from "./pages/products/Product";
import Category from "./pages/categories/Category";
import Fee from "./pages/fees/Fee";
import User from "./pages/users/User";
import NotMatch from "./pages/errors/NotMatch";

export default function Routes(props) {
  return (
    <Switch>
      <Route exact path="/">
        <Dashboard />
      </Route>
      <Route path="/orders">
        <Order />
      </Route>
      <Route path="/products">
        <Product />
      </Route>
      <Route path="/categories">
        <Category />
      </Route>
      <Route path="/fees">
        <Fee />
      </Route>
      <Route path="/users">
        <User />
      </Route>
      <Route path="*">
        <NotMatch />
      </Route>
    </Switch>
  );
}