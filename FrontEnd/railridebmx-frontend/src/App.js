import './App.css';
import NavBar from './Components/NavBar/NavBar.js';
import Register from './Components/Register/Register.js'


fetch('https://localhost:7134/api/Bmx').then((response) =>{
  response = response.json()
  response.then((result) => {
    console.log(result)
  })
})
function App() {
  return (
    <div>
      <NavBar />
      <Register />
    </div>
  );
}

export default App;
