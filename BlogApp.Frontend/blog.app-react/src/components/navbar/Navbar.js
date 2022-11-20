import React from 'react'
import { Outlet, Link } from 'react-router-dom'
import { useAuth0 } from '@auth0/auth0-react'

const Navbar = () => {

  const { loginWithRedirect, logout, isAuthenticated } = useAuth0();

  return (
    <>
      <nav className="navbar-bg navbar navbar-expand-lg navbar-light bg-light py-3 px-3">
        <i className="fa-solid fa-blog"></i>
        <Link className="navbar-brand" to="/" href="#">BlogApp</Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse p-2 justify-content-between" id="navbarNavAltMarkup">
          <div className="navbar-nav">
            <Link id='first-navlink' className="nav-item nav-link shadow" to="/">Home</Link>
            <Link className="nav-item nav-link shadow" to="/posts" >Posts</Link>
            <Link className="nav-item nav-link shadow" to="/addpost">Add post</Link>
            <Link className="nav-item nav-link shadow" to="/addpicture">Add picture</Link>
          </div>
          <div className="navbar-nav auth-buttons">
            {!isAuthenticated && <Link className="nav-item nav-link shadow" onClick={() => loginWithRedirect()}>Login</Link>}
            {isAuthenticated && <Link className="nav-item nav-link shadow" to='/profile'>Profile</Link>}
            {isAuthenticated && <Link className="nav-item nav-link shadow" onClick={() => logout({ returnTo: window.location.origin })}>Logout</Link>}
          </div>
        </div>
      </nav>
      <Outlet />

    </>
  )
}

export default Navbar