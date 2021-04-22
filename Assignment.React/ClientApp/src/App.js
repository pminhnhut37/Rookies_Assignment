import { BrowserRouter as Router } from "react-router-dom";
import Header from "./components/Header";
import Navigate from "./components/Navigation";
import PageLayout from "./containers/PageLayout";
import Routes from "./route";

function App() {
  return (
    <Router>
      <PageLayout header={<Header />} nav={<Navigate />} content={<Routes />} />
    </Router>
  );
}
