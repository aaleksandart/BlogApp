import React from 'react'
import { Outlet, Link } from 'react-router-dom'

const Navbar = () => {
  return (
    <>

      <nav className="navbar-bg navbar navbar-expand-lg navbar-light bg-light py-3 px-3 shadow">
        <Link className="navbar-brand" to="/" href="#">BlogApp</Link>
        <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse p-2" id="navbarNavAltMarkup">
          <div className="navbar-nav">
            <Link className="nav-item nav-link ms-5" to="/">Home</Link>
            <Link className="nav-item nav-link" to="/posts" >Posts</Link>
            <Link className="nav-item nav-link" to="/addpost">Add post</Link>
          </div>
        </div>
      </nav>
      <Outlet />

    </>
  )
}

export default Navbar