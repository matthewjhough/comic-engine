import { connect } from 'react-redux';
import { ComicSearchForm } from './ComicSearchForm';
import {
  updateTitleInput,
  updateIssueNumberInput,
  updateResultsFromForm
} from './comicSearchFormActions';
import {
  toggleLoading,
  setSelectedComic
} from '../ComicResults/comicResultsActions';
import { createUserComic } from '../UserComics/CreateUserComic/createUserComicAction';

const mapStateToProps = ({ comicSearchForm, comicResults, storageContainers }) => ({
  ...comicSearchForm,
  ...comicResults,
  storageContainers
});

const mapDispatchToProps = dispatch => ({
  updateTitleInput: title => dispatch(updateTitleInput(title)),
  updateIssueNumberInput: issueNumber => dispatch(updateIssueNumberInput(issueNumber)),
  updateResultsFromForm: dispatch(updateResultsFromForm),
  toggleComicSearchLoadingTrue: () => dispatch(toggleLoading(true)),
  setSelectedComic: comic => dispatch(setSelectedComic(comic)),
  makeSaveComicRequest: (selectedComic, selectedContainer) => 
      dispatch(createUserComic(selectedComic, selectedContainer))
});

export const ComicSearchFormContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ComicSearchForm);
