import { Routes, Route } from 'react-router-dom';
import DOMPurify from 'dompurify'
import './App.css';

//Components
import Navbar from './components/navbar/Navbar.js'

//Auth
import RouteSecurity from './auth/RouteSecurity.js'

//Pages
import Home from './pages/home/index.js'
import Posts from './pages/posts/index.js'
import AddPost from './pages/addpost/index.js'
import AddPicture from './pages/addpicture/index.js'
import Profile from './pages/profile/index.js'
import NoAuth from './pages/noauth/index.js'

function App() {

  //Setting sanitize settings to allow <b> and <i> tags
  const WHITELISTED_TAGS = ['b', 'i']
  DOMPurify.setConfig({
    ALLOWED_TAGS: WHITELISTED_TAGS
  })

  return (
    <>
      <Routes>
        <Route path='/' element={<Navbar />}>
          <Route index element={<Home />} />
          <Route path='posts' element={<Posts />} />
          <Route path='addpost' element={<RouteSecurity component={AddPost} />} />
          <Route path='addpicture' element={<RouteSecurity component={AddPicture} />} />
          <Route path='profile' element={<Profile />} />
          <Route path='noAuth' element={<NoAuth />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
