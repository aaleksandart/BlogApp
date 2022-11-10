import React from 'react'

const PostsForm = () => {
  return (
    <>
        <form>
            <div className='input-comp'>
                <label htmlFor="">Post title</label>
                <input className='shadow' type="text" />
            </div>
            <div className='input-comp'>
                <label htmlFor="">Post</label>
                <textarea className='shadow' type="text" />
            </div>
            <div className='input-comp'>
                <label htmlFor="">Image URL</label>
                <input className='shadow' type="text" />
            </div>
        </form>
    </>
  )
}

export default PostsForm