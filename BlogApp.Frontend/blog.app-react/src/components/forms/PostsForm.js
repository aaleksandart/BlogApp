import React from 'react'
import DOMPurify from 'dompurify'
import { useAuth0 } from '@auth0/auth0-react'

//Hook
import UseForm from './UseForm.js'

//Validation
import FormValidation from './FormValidation.js'

const PostsForm = () => {

    const { handleChange, handleSubmit, formValues, formErrors } = UseForm(submitPost, FormValidation)
    const { getAccessTokenSilently, getIdTokenClaims } = useAuth0();

    function submitPost() {
        let jsonPost = JSON.stringify({
            postTitle: DOMPurify.sanitize(formValues.postTitle),
            postBody: DOMPurify.sanitize(formValues.postBody),
            imageUrl: DOMPurify.sanitize(formValues.imageUrl)
        })

        async function postPost() {
            let result;
            const connErrors = document.getElementById('connError');

            const aToken = getAccessTokenSilently();
            const idToken = await getIdTokenClaims();
            console.log(aToken)
            console.log(idToken)

            try {
                result = await fetch('https://localhost:7222/api/Posts', {
                    method: 'post',
                    headers: {
                        "Content-Type": "application/json",
                        "Authorization": `bearer ${aToken}`
                    },
                    body: jsonPost
                });
            } catch (e) {
                console.log(e);
            }
            console.log(result.status)
            if (result.status === 200) {
                connErrors.classList.add('d-none')
                window.location.replace('http://localhost:3000/')
            } else {
                connErrors.classList.add('d-block')
            }
        }
        postPost();
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div className='input-comp'>
                    <label htmlFor="">Post title</label>
                    <input id='postTitle' name='postTitle' className='shadow' type="text" value={formValues.postTitle} onChange={handleChange} />
                    {formErrors.postTitle && <small className="text-danger ms-1">{formErrors.postTitle}</small>}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Post</label>
                    <textarea id='postBody' name='postBody' className='shadow' type="text" value={formValues.postBody} onChange={handleChange} />
                    {formErrors.postBody && <small className="text-danger ms-1">{formErrors.postBody}</small>}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Image URL</label>
                    <input id='imageUrl' name='imageUrl' className='shadow' type="text" value={formValues.imageUrl} onChange={handleChange} />
                    {formErrors.imageUrl && <small className="text-danger ms-1">{formErrors.imageUrl}</small>}
                </div>
                <button className='shadow' id='submitPost'>Submit</button>
                <div id='connError' className='connError shadow'>
                    <span id='connErrorText'>Database connection error. Save not completed.</span>
                </div>
            </form>
        </>
    )
}

export default PostsForm