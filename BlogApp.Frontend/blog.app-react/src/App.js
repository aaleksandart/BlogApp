import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';

//Components
import Navbar from './components/navbar/Navbar.js'

//Pages
import Home from './pages/home/index.js'
import Posts from './pages/posts/index.js'
import AddPost from './pages/addpost/index.js'
import AddPicture from './pages/addpicture/index.js'
import Profile from './pages/profile/index.js'
import NoAuth from './pages/noauth/index.js'

function App() {
  return (
    <>
        <BrowserRouter>
          <Routes>
            <Route path='/' element={<Navbar />}>
              <Route index element={<Home />} />
              <Route path='posts' element={<Posts />} />
              <Route path='addpost' element={<AddPost />} />
              <Route path='addpicture' element={<AddPicture />} />
              <Route path='profile' element={<Profile />} />
              <Route path='noAuth' element={<NoAuth />} />
            </Route>
          </Routes>
        </BrowserRouter>
    </>
  );
}

export default App;
