import './App.css';

import {Home} from './Home';
import {ViewProducts} from './ViewProducts';
import {ViewCategories} from './ViewCategories';
import {Navigation} from './Navigation';

import {BrowserRouter, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
    <div className="">
     <h3 className="m-3 d-flex justify-content-center">
       Test
     </h3>

     <Navigation/>

     <Switch>
       <Route path='/' component={Home} exact/>
       <Route path='/products' component={ViewProducts}/>
       <Route path='/categories' component={ViewCategories}/>
     </Switch>
    </div>
    </BrowserRouter>
  );
}

export default App;